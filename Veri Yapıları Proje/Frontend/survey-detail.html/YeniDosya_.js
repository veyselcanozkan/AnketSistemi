document.addEventListener("DOMContentLoaded", function () {
    const surveyContainer = document.getElementById("Anket_Alanı");
    const submitSurvey = document.getElementById("Gönder");
    const surveyData = [
        {
            Soru: "Mağazamız hijyenik açıdan temizdi.",
            Şıklar: ["Kesinlikle katılmıyorum.","Katılmıyorum.","Kararsızım.","Katılıyorum.","Kesinlikle Katılıyorum."]
        }
        ,
        {
            Soru: "Mağaza personeli gerektiğinde size yardımcı olabildi.",
            Şıklar: ["Kesinlikle katılmıyorum.","Katılmıyorum.","Kararsızım.","Katılıyorum.","Kesinlikle Katılıyorum."]
        }
        ,
        {
            Soru: "Mağazamızda aradığınız ürünü kolaylıkla bulabildiniz.",
            Şıklar: ["Kesinlikle katılmıyorum.","Katılmıyorum.","Kararsızım.","Katılıyorum.","Kesinlikle Katılıyorum."]
        }  
        ,
        {    
          Soru: "Mağazamıza ne kadar sıklıkla geliyorsunuz?",
          Şıklar: ["İlk defa geliyorum.","Arada bir geliyorum.","Bazen geliyorum.","Genellikle geliyorum.","Her zaman geliyorum."]  
        }
    ];
    surveyData.forEach((Soru_, index) => {
        const card = document.createElement("div");
        card.classList.add("card", "shadow", "mb-3");
        const header = document.createElement("div");
        header.classList.add("card-header", "bg-primary", "text-white");
        header.innerHTML = `<h4>${Soru_.Soru}</h4>`; 
        const body = document.createElement("div");
        body.classList.add("card-body");
        Soru_.Şıklar.forEach(Şıklar => {
            const div = document.createElement("div");
            div.classList.add("form-check");
    
            const input = document.createElement("input");
            input.classList.add("form-check-input");
            input.type = "radio";
            input.name = `Soru_${index}`;
            input.value = Şıklar;
            input.id = `${Şıklar}${index}`;
    
            const label = document.createElement("label");
            label.classList.add("form-check-label");
            label.htmlFor = input.id;
            label.textContent = Şıklar;
    
            div.appendChild(input);
            div.appendChild(label);
            body.appendChild(div);
        });
        card.appendChild(header);
        card.appendChild(body);
        surveyContainer.appendChild(card);
    });
    submitSurvey.addEventListener("click", function () {
        let Sonuçlar = [];
        let OyKullanıldı=true;
        for(let i=0;i<surveyData.length;i++){
            const selectedOption = document.querySelector(`input[name="Soru_${i}"]:checked`);
            if(selectedOption){
                Sonuçlar.push({
                    Soru:surveyData[i].Soru ,
                    Şık:selectedOption.value
                })
            }
            else{
                alert("Bütün soruların cevaplanması zorunludur.")
                OyKullanıldı=false;
                return;
            }
        }
        if(!OyKullanıldı){
            Sonuçlar.length=0;
        }
        else {
            alert("Yanıtlama işlemi tamamlanmıştır.");
            //Backend eklenecektir.
            fetch("", 
                {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ Sonuçlar }) 
            })
            .then(Sonuçlar => Sonuçlar.json())
            .then(data => {
                console.log("Başarılı:", data);
            })
            .catch(error => {
                console.error("Error:", error);
            });
        }
    });
});

        


