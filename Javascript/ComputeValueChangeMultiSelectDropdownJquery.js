let listasParaPreencher = $('.form-select');

listasParaPreencher.each(posicao => {
    let dropdownActual = listasParaPreencher[posicao];

    dropdownActual.addEventListener('change', e => {
       
        let campo = $(dropdownActual).parent().find('.campo_adicional');
        campo.empty();

        let multivalores = dropdownActual.selectedOptions;
        let valoresSelecionados = [];
        $(multivalores).each(p => valoresSelecionados.push(multivalores[p].innerText));

        let valoresAgrupadosPorVirgula = valoresSelecionados.length > 0 ? "Valores selecionados: " : "";
        valoresSelecionados.forEach(v => {
            valoresAgrupadosPorVirgula += v + ",";
        });

        campo.text(valoresAgrupadosPorVirgula);
    });
})
