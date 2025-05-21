from fastapi import FastAPI, File, UploadFile
from fastapi.responses import JSONResponse
from ultralytics import YOLO
import cv2
import numpy as np
import base64
import statistics
import os

app = FastAPI()

script_dir = os.path.dirname(os.path.abspath(__file__))
model_path = os.path.join(script_dir, "modelos", "best.pt")
model = YOLO(model_path)

@app.post("/predict")
async def predict(files: list[UploadFile] = File(...)):
    results_info = []
    confiancas_maduros = []
    confiancas_verde = []
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
            conf = float(box.conf)
            if int(box.cls) == 1:
                qntMaduros += 1
                confiancas_maduros.append(round(conf * 100, 2))
            else:
                confiancas_verde.append(round(conf * 100, 2))
            
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

    media_maduros = 0
    desvioPadrao_maduros = 0
    if confiancas_maduros.count>0: 
        media_maduros = statistics.mean(confiancas_maduros)
        desvioPadrao_maduros = statistics.stdev(confiancas_maduros)

    media_verde = 0
    desvioPadrao_verde = 0
    if confiancas_verde.count>0: 
        media_verde = statistics.mean(confiancas_verde)
        desvioPadrao_verde = statistics.stdev(confiancas_verde)

    return JSONResponse(content={
        "total_tomates": qntTomates,
        "maduros": qntMaduros,
        "media_confianca_maduros": round(media_maduros, 2),
        "media_confianca_verde": round(media_verde, 2),
        "desvio_confianca_maduros": round(desvioPadrao_maduros, 2),
        "desvio_confianca_verde": round(desvioPadrao_verde, 2),
        "results": results_info})

if __name__ == "__main__":
    import uvicorn
    uvicorn.run("server:app", host="127.0.0.1", port=8000, reload=True)  # LOCAL
    #port = int(os.environ.get("PORT", 8000))
    #uvicorn.run("server:app", host="0.0.0.0", port=port)  

