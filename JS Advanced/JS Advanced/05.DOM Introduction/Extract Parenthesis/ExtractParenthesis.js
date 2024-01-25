function extract(content) {
    let textElementContent = document.getElementById(content).textContent;

    const texts = [];
    let start = textElementContent.indexOf("(");

    while (start !== -1) {
        const end = textElementContent.indexOf(")", start + 1);
        if (end === -1) break;
        const extractedText = textElementContent.substring(start + 1, end);
        texts.push(extractedText);
        start = textElementContent.indexOf("(", end + 1);
    }

    return texts.join("; ");
}