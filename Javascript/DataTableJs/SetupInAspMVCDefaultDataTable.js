 <script src="~/lib/jquery/dist/jquery.min.js"></script>
 <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
 <script src="~/js/site.js" asp-append-version="true"></script>
 <script src="https://cdn.datatables.net/1.13.7/js/jquery.dataTables.js"></script>

 <script>
     $(document).ready(function () {
         $('.grid-table').DataTable({
             paging: true,
             ordering: true,
             searching: true
         });
     });
 </script>
