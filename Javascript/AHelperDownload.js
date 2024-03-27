let download = (base64Content, filename) => {
    // Decodifica o Base64 para uma string binária
    let binaryContent = atob(base64Content);
    // Converte a string binária para um array de bytes
    let byteNumbers = new Array(binaryContent.length);
    for (let i = 0; i < binaryContent.length; i++) {
        byteNumbers[i] = binaryContent.charCodeAt(i);
    }
    let byteArray = new Uint8Array(byteNumbers);

    // Cria um Blob com o array de bytes
    let blob = new Blob([byteArray], { type: 'text/plain;charset=utf-8' });
    let uriContent = URL.createObjectURL(blob);
    let link = document.createElement('a');
    link.setAttribute('href', uriContent);
    link.setAttribute('download', filename);
    document.body.appendChild(link); // Adiciona o link ao corpo do documento para garantir a compatibilidade
    link.click();
    document.body.removeChild(link); // Remove o link do corpo do documento após o download
};


let arquivosEncontrados = document.getElementsByClassName('file-downloader');

for (let i = 0; i < arquivosEncontrados.length; i++) {
    arquivosEncontrados[i].addEventListener('click', function (e) {
        e.preventDefault();

        let fileName = e.target.getAttribute('file-name');

        let base64Data = e.target.getAttribute('data');

        download(base64Data, fileName);
    });
}
