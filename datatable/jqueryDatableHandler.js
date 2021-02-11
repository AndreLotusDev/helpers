//Exemplo usando XML e percorrendo colunas e rows especificos

extend: 'excelHtml5',
text: "<span><img src='../Content/Icons/excel.png' alt='Excel'></span>",
className: "btn btn-circle-custom",
exportOptions: {
    orthogonal: 'export',
    rows: function (idx, data, node)
    {
        const dt = new $.fn.dataTable.Api('#dtRelatorio');
        const selected = dt.rows({ selected: true }).indexes().toArray();
        //Funcao com RGEX, q formata as columns com link pro excel
        for (var i = 0; i <= data.length; i++)
        {
            if (data[i] != undefined)
            {
                if (data[i].includes(`alt="PDF"`))
                {
                    //Caso a coluna esteja vazia
                    if (data[i] == "")
                        continue;

                    var formatado = data[i].match(/href="([^"]*")/g)

                    //Cria o text para mandar para o XML do Datatable
                    if (formatado != null)
                    {
                        data[i] = formatado[0].split(`"`)[1]
                        data[i] = `"${data[i]}" , "DOC"`
                    }
                }
            }
        }

        if (selected.length === 0 || $.inArray(idx, selected) !== -1)
            return true;
        return false;
    },
    columns: [0, ':visible']
},
customize: function (xlsx)
{
    var sheet = xlsx.xl.worksheets['sheet1.xml'];
    var col = $('col', sheet);

    var indexTitulos = []
    var indexRow = 0
    var indexColumn = 0

    $('row', sheet).each(function ()
    {
        indexColumn = 0
        if (indexRow > 0 && indexRow <= 1)
        {
            $('c', this).each(function ()
            {
                //Verifica se é um arquivo com link
                if ($('is t', this).text().includes("Link"))
                {
                    $(col[indexColumn]).attr('width', 10)
                }

                indexColumn++
            })
        }

        $('c', this).each(function ()
        {

            if ($('is t', this).text().includes("http:"))
            {
                $(this).attr('t', 'str');
                //append the formula -> pega o dado formatado da coluna q utiliza o RGEX
                $(this).append('<f>' + 'HYPERLINK(' + $('is t', this).text() + ')' + '</f>');
                //remove the inlineStr
                $('is', this).remove();
                // (3.) underline
                $(this).attr('s', '4');
            }
        })
        indexRow++
    });
},