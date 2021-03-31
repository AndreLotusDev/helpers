
/// <summary>
/// Essas 3/4 funções em conjunto conseguem realizar a pesquisa pelo backend (Quando tem processamento pesado)
/// </summary>

public List<Teste> GetDataFromDbase(string searchBy, int take, int skip, string sortBy,
           bool sortDir, out int filteredResultsCount, out int totalResultsCount)
{

    using (var db = new DbEntities())
    {
        var result = db
                        .Processos

                        .Where(m =>
                            string.IsNullOrEmpty(searchBy) ||
                            (m.NUMPASTA.ToString().ToLower() == searchBy.ToLower() ||
                            m.NOMREU.ToLower() == searchBy.ToLower())
                        )

                       .AsQueryable()

                       .Select(m => new Teste
                       {
                           Teste1 = m.CAMPO1,
                           Teste2 = m.CAMPO2,
                       })
                       .ToList()

                       .Skip(skip)

                       .Take(take);


        if (string.IsNullOrEmpty(searchBy))
        {
            result = result.OrderBy(m => m.Teste1).ToList(); // have to give a default order when skipping .. so use the PK
        }

        // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
        filteredResultsCount = leafJuridico.Processos.AsQueryable().Where(m => m.NUMPASTA.ToString().ToLower() == searchBy.ToLower() || m.NOMREU.ToLower() == searchBy.ToLower()).Count();
        totalResultsCount = leafJuridico.Processos.AsQueryable().Count();

        return result.ToList();
    }
}


public IList<Teste> YourCustomSearchFunc(DataTableAjaxPostModel model, out int filteredResultsCount, out int totalResultsCount)
{
    var searchBy = (model.search != null) ? model.search.value : null;
    var take = model.length;
    var skip = model.start;

    string sortBy = "";
    bool sortDir = true;

    if (model.order != null)
    {
        // in this example we just default sort on the 1st column
        sortBy = model.columns[model.order[0].column].data;
        sortDir = model.order[0].dir.ToLower() == "asc";
    }

    // search the dbase taking into consideration table sorting and paging
    var result = GetDataFromDbase(searchBy, take, skip, sortBy, sortDir, out filteredResultsCount, out totalResultsCount);
    if (result == null)
    {
        // empty collection...
        return new List<Teste>();
    }
    return result;
}

public JsonResult CustomSearch(DataTableAjaxPostModel model)
{
    // action inside a standard controller
    int filteredResultsCount;
    int totalResultsCount;
    var res = YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);

    return Json(new
    {
        // this is what datatables wants sending back
        draw = model.draw,
        recordsTotal = totalResultsCount,
        recordsFiltered = filteredResultsCount,
        data = res
    });
}

/// <summary>
/// Predicado caso vc precise de um where mais consisso
/// </summary>
private Expression<Func<DatabaseTableMappedClass, bool>> BuildDynamicWhereClause(DBEntities entities, string searchValue)
{
    // simple method to dynamically plugin a where clause
    var predicate = PredicateBuilder.New<DatabaseTableMappedClass>(true); // true -where(true) return all
    if (String.IsNullOrWhiteSpace(searchValue) == false)
    {
        // as we only have 2 cols allow the user type in name 'firstname lastname' then use the list to search the first and last name of dbase
        var searchTerms = searchValue.Split(' ').ToList().ConvertAll(x => x.ToLower());

        predicate = predicate.Or(s => searchTerms.Any(srch => s.Firstname.ToLower().Contains(srch)));
        predicate = predicate.Or(s => searchTerms.Any(srch => s.Lastname.ToLower().Contains(srch)));
    }
    return predicate;
}