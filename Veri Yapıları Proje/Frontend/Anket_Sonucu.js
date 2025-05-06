const grafik=document.getElementById("resultsChart");
const data={
    'Python':10,
    'C++':50,
    'C#':10,
    'Angular':10
}
/*---------------------Backend
fetch("",
{

})
*/
const Grafik=new Chart(grafik,{
    type:'bar',
    data:{
        labels:Object.keys(data),
        datasets:[
            {
            label:"Programlama Anketi",
            data:Object.values(data)
            }
        ]
    },

});
