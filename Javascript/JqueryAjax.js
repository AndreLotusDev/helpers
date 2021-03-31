 $.ajax({
        url: "OpenPdf",
        type: "POST",
        data: infoProController,
        async: true,
        success: function (conteudo)
        {
            if (conteudo.sucess)
            {
                let win = ""
                if (conteudo.pathLocation != "")
                {
                    window.open(conteudo.pathLocation, '_blank', false)
                    win.focus()
                }
            }
            else
            {
                alert(conteudo.responseText)
            }
        },
        error: function (conteudo)
        {
        },
    });