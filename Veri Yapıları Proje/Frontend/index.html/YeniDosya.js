document.getElementById("loginForm").addEventListener("submit",async function a(event){
    const e_Posta=document.getElementById("email").value;
    const sifre=document.getElementById("password").value;
    try{
        let response=await fetch(""//Node.Js buraya gelecektir(?)
            ,{
            method:"POST",
            headers:{"Content-Type":"application/json"},
            body:JSON.stringify({e_Posta,sifre})
        });
        let sonuc=await response.json();
        if (response.ok) {
            console.log("Token:", sonuc.token);
            localStorage.setItem("token", sonuc.token);
            window.location.href="";//Hesap sitesi ya da anasayfaya atmalıdır.
        } else {
            alert("Giriş başarısız: " + result.message);
        }
    } catch (error) {
        console.error("Hata:", error);
        alert("Bir hata oluştu, tekrar deneyin.");
    }
});

