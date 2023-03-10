// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrganizationMaster.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace OrganizationMaster.Data
{
    public partial interface IFirstDBContextProcedures
    {
        Task<List<crudtblcountryResult>> crudtblcountryAsync(int? Id, string CountryName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_Branch_ByIdResult>> USP_Branch_ByIdAsync(int? Branch_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Branch_DeleteAsync(int? Branch_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Branch_InsertAsync(int? Oraganization_Id, string BranchName, string PhoneNumber, string Email, string Fax, int? City_Id, string ZipCode, string Address, string Note, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Branch_UpdateAsync(int? Branch_Id, string BranchName, string PhoneNumber, string Email, string Fax, int? City_Id, string ZipCode, string Address, string Note, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_City_ByIdResult>> USP_City_ByIdAsync(int? City_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_City_DeleteAsync(int? City_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_City_InsertAsync(int? State_Id, string CityName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_City_UpdateAsync(int? City_Id, string CityName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_Country_ByIdResult>> USP_Country_ByIdAsync(int? Country_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Country_DeleteAsync(int? Country_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Country_InsertAsync(string CountryName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Country_UpdateAsync(int? Country_Id, string CountryName, OutputParameter<string> Message, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_Department_ByIdResult>> USP_Department_ByIdAsync(int? Department_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Department_DeleteAsync(int? Department_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Department_InsertAsync(int? Oraganization_Id, int? Branch_Id, string DepartmentName, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Department_UpdateAsync(int? Department_Id, int? Oraganization_Id, int? Branch_Id, string DepartmentName, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_Designation_ByIdResult>> USP_Designation_ByIdAsync(int? Designation_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Designation_DeleteAsync(int? Designation_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Designation_InsertAsync(int? Oraganization_Id, int? Branch_Id, int? Department_Id, string DesignationName, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Designation_UpdateAsync(int? Designation_Id, int? Oraganization_Id, int? Branch_Id, int? Department_Id, string DesignationName, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Oraganization_InsertAsync(string OraganizationName, string RegistrationNumber, string PhoneNumber, string Email, string Fax, int? City_Id, string Prefix, string ZipCode, string Address, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_Organization_ByIdResult>> USP_Organization_ByIdAsync(int? Oraganization_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Organization_DeleteAsync(int? Oraganization_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_Organization_UpdateAsync(int? Oraganization_Id, string OraganizationName, string RegistrationNumber, string PhoneNumber, string Email, string Fax, int? City_Id, string Prefix, string ZipCode, string Address, bool? IsActive, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<USP_State_ByIdResult>> USP_State_ByIdAsync(int? State_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_State_DeleteAsync(int? State_Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_State_InsertAsync(int? Country_Id, string CountryName, string StateName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> USP_State_UpdateAsync(int? State_Id, string StateName, OutputParameter<string> Message, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        //void SendEmail(Emaildto request);
        Task<int> USP_Employee_Insert(string EmployeeName, string DepartmentName,string Salary, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);

    }
}
