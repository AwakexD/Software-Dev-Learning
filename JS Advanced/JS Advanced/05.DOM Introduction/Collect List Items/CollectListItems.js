function extractText() {
    let liElements = document.querySelectorAll("ul li");
    let textBox = document.getElementById("result");
    let string = "";
    
   for (const item of liElements) {
        textBox.textContent += item.textContent + "\n";
   }
}