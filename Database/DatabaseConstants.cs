using System.Data.Common;

namespace TmTaskManagerApi.Database
{
    public static class DatabaseConstants
    {
        public static string DbConnectionStr = "UserID=postgres;Password=Taxback@1!;Host=localhost;Port=5432;Database=TmTaskManager;Pooling=true";

        public static string AllTask = "select * from public.task where is_active = true";

        public static string SpecificTask = "select * from public.task where id = {0} and is_active = true";

        public static string AddTask = "INSERT INTO public.task(title, description, task_type, status_id, assigned_to, created_date, required_date, created_on, updated_on)VALUES ( '{0}', '{1}', {2}, {3}, {4}, '{5}', '{6}', '{7}', '{8}');";

        public static string UpdateTask = "UPDATE public.task SET title='{0}', description='{1}', task_type={2}, status_id={3}, assigned_to={4}, required_date='{5}', updated_on='{6}' WHERE id = {7};";

        public static string DeleteTask = "UPDATE public.task SET is_active = false, updated_on = '{0}'  WHERE id = {1}";

        public static string AllComment = "select * from public.comment where is_active = true";
    }
}
