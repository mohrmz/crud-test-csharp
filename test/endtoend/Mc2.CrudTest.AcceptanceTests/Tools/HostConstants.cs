﻿namespace Mc2.CrudTest.AcceptanceTests.Tools
{
    public static class HostConstants
    {

        public static readonly string CsProjectPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName + "\\src\\03_Presentations\\Mc2.CrudTest.EndPoints.API\\Mc2.CrudTest.EndPoints.API.csproj";
        public const int Port = 5001;
        public static readonly string Endpoint = $"https://localhost:{Port}/";
    }
}
