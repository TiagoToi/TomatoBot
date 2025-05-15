from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
from ultralytics import YOLO
import cv2
import numpy as np
import base64
import statistics

app = FastAPI()

model = YOLO("C:\\Users\\TiagoToi\\OneDrive - Taxcel\\Documentos\\Puc\\TomatoTrack\\API Python\\modelos\\best.pt")

@app.post("/predict")
async def predict(files: list[UploadFile] = File(...)):
    results_info = []
    confiancas = []
    qntTomates = 0
    qntMaduros = 0

    for file in files:
        contents = await file.read()
        nparr = np.frombuffer(contents, np.uint8)
        image = cv2.imdecode(nparr, cv2.IMREAD_COLOR)

        results = model(image, conf=0.5)
        r = results[0]
        im_array = r.plot()
        

        for box in r.boxes:
            qntTomates += 1
            if int(box.cls) == 1:
                qntMaduros += 1
            conf = float(box.conf)
            confiancas.append(round(conf * 100, 2))        

        # Codifica imagem como JPEG e depois para Base64
        success, im_encoded = cv2.imencode('.jpg', im_array)
        if not success:
            results_info.append({
                "filename": file.filename,
                "status": "erro na codificação"
            })
            continue

        image_base64 = base64.b64encode(im_encoded).decode("utf-8")

        results_info.append({
            "filename": file.filename,
            "image_base64": image_base64,
            "status": "ok"
        })

    media = statistics.mean(confiancas)
    desvioPadrao = statistics.stdev(confiancas)

    return JSONResponse(content={
        "total_tomates": qntTomates,
        "maduros": qntMaduros,
        "media_confianca": round(media, 2),
        "desvio_confianca": round(desvioPadrao, 2),
        "results": results_info})

if __name__ == "__main__":
    import uvicorn
    uvicorn.run("server:app", host="127.0.0.1", port=8000, reload=True)
