document.getElementById("Login").addEventListener("submit", function (e) {
    document.getElementById("preloader").style.display = "block";
    setTimeout(() => {
         document.getElementById("preloader").style.display = "none";
    },1250);
});