using System.Data.Common;

namespace TmTaskManagerApi.Database
{
    public static class DatabaseConstants
    {
        public static string DbConnectionStr = "UserID=postgres;Password=Taxback@1!;Host=localhost;Port=5432;Database=TmTaskManager;Pooling=true";

        public static string AllTask = "select * from public.task";

        public static string SpecificTask = "select * from public.task where id = {0}";

        public static string AddTask = "INSERT INTO public.task(title, description, task_type, status_id, assigned_to, created_date, required_date, created_on, updated_on)VALUES ( '{0}', '{1}', {2}, {3}, {4}, '{5}', '{6}', '{7}', '{8}');";
    }
}
