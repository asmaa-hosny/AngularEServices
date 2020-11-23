using ERP_EmployeeServices;
using EServicesWithAngular.Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using EServicesWithAngular.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace EServicesWithAngular.DAL.ECHOServices
{
    public class ECHO_Employee
    {
        static EmployeeServiceClient _empSvc;

        public static EmployeeServiceClient empSvc
        {
            get
            {
                return _empSvc ?? (_empSvc = new EmployeeServiceClient());
            }
        }

        public static EmployeeModel getCurrentUserEmployeeModel(String username)
        {
           
            employee theEmp = null;
            theEmp = empSvc.findByEmailAsync(username.Substring(username.LastIndexOf("\\") + 1) + "@energy.gov.sa").GetAwaiter().GetResult().employee;
           
            EmployeeModel emp = getEmployeeModel(theEmp);
            emp.Username = username;
            return emp;
        }
        public static EmployeeModel findEmployeeWithEmail(String employeeEmail)
        {
           
            employee theEmp = null;
            bool done = false;
            for (int i = 0; !done && i < 3; i++)
            {
                try
                {
                    theEmp = empSvc.findByEmailAsync(employeeEmail).GetAwaiter().GetResult().employee;
                    done = true;
                }
                catch (Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            EmployeeModel emp = getEmployeeModel(theEmp);
            emp.Username = "ENERGY\\" + employeeEmail.Substring(0, employeeEmail.IndexOf("@"));
            return emp;
        }

        public static EmployeeModel findEmployeeWithID(long employeeID)
        {
           

            employee theEmp = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    theEmp = empSvc.findoneAsync(employeeID).GetAwaiter().GetResult().employee;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            return getEmployeeModel(theEmp);
        }
        public static EmployeeModel findEmployeeWithKACARE_ID(string kacare_id)
        {
           

            employee theEmp = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    theEmp = empSvc.findBy_KACARE_IdAsync(kacare_id).GetAwaiter().GetResult().employee;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            return getEmployeeModel(theEmp);
        }

        public static List<employeeMates> findEmployeeDependents(long employeeID)
        {
           

            employeeMates[] mates = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    mates = empSvc.findEmployeeMatesAsync(employeeID).GetAwaiter().GetResult().empmates;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            List<employeeMates> dependents = new List<employeeMates>();

            if (mates == null)
                return dependents;

            foreach (employeeMates oneMate in mates)
            {
                dependents.Add(oneMate);
            }

            return dependents;
        }

        public static List<SelectListItem> getVendorsList()
        {
           

            vendor[] vendorList = ECHO_Cache.AllVendors;
            if (vendorList == null)
            {
                bool done = false;
                for (int i = 0; i < 3 && !done; i++)
                {
                    try
                    {
                        vendorList = ECHO_Cache.AllVendors = empSvc.loadAllVendorsAsync().GetAwaiter().GetResult().vendor;
                        done = true;
                    }
                    catch (System.Exception e)
                    {
                        if (i == 2)
                            throw e;
                        Thread.Sleep(1500);
                    }
                }
            }
            List<SelectListItem> vendors = new List<SelectListItem>();
            foreach (vendor oneVendor in vendorList)
            {
                SelectListItem item = new SelectListItem();
                item.Text = oneVendor.name;
                item.Value = oneVendor.employeeid.ToString();
                vendors.Add(item);
            }

            return vendors.OrderBy(x => x.Text).ToList();
        }

        private static EmployeeModel getEmployeeModel(employee theEmp)
        {
            EmployeeModel theEmpModel = new EmployeeModel();

            theEmpModel.EmployeeID = theEmp.id;
            theEmpModel.EmpCode = theEmp.empcode;
            theEmpModel.Grade = theEmp.grade;
            theEmpModel.EmployeeEmail = theEmp.email;
            theEmpModel.HireDate = theEmp.hiredate;
            theEmpModel.PassportNo = theEmp.passportno;
            theEmpModel.DefaultAirClass = theEmp.airclasscode;
            theEmpModel.EmployeeDepartmentManagerEmail = theEmp.deptmanageremail;
            theEmpModel.EmployeeManagerEmail = theEmp.supervisoremail;
            theEmpModel.EmployeeNameAR = theEmp.name;
            theEmpModel.EmployeeManagerAR = theEmp.supervisorname;
            theEmpModel.EmployeeDepartmentManagerAR = theEmp.deptmanagername;
            theEmpModel.EmployeeDepartmentAR = theEmp.departmentname;
            theEmpModel.JobTitleAR = theEmp.jobtitlear;
            theEmpModel.NationalityAR = theEmp.nationality;
            theEmpModel.SectionNameAR = theEmp.sectionname;
            theEmpModel.GreetingAR = theEmp.greetingar;

            theEmpModel.EmployeeNameEN = theEmp.nameeng;
            theEmpModel.EmployeeManagerEN = theEmp.supervisornameeng;
            theEmpModel.EmployeeDepartmentManagerEN = theEmp.deptmanagernameeng;
            theEmpModel.EmployeeDepartmentEN = theEmp.departmentdescription;
            theEmpModel.JobTitleEN = theEmp.jobtitle;
            theEmpModel.NationalityEN = theEmp.nationalityar;
            theEmpModel.SectionNameEN = theEmp.sectiondescription;
            theEmpModel.GreetingEN = theEmp.greetingen;
            theEmpModel.Mobile = theEmp.mobile;


            theEmpModel.EmployeeName = theEmp.name;
            theEmpModel.EmployeeManager = theEmp.supervisorname;
            theEmpModel.EmployeeDepartmentManager = theEmp.deptmanagername;
            theEmpModel.EmployeeDepartment = theEmp.departmentname;
            theEmpModel.JobTitle = theEmp.jobtitlear;
            theEmpModel.Nationality = theEmp.nationality;
            theEmpModel.SectionName = theEmp.sectionname;
            theEmpModel.Greeting = theEmp.greetingar;

            theEmpModel.EmployeeName = theEmp.nameeng;
            theEmpModel.EmployeeManager = theEmp.supervisornameeng;
            theEmpModel.EmployeeDepartmentManager = theEmp.deptmanagernameeng;
            theEmpModel.EmployeeDepartment = theEmp.departmentdescription;
            theEmpModel.JobTitle = theEmp.jobtitle;
            theEmpModel.Nationality = theEmp.nationalityar;
            theEmpModel.SectionName = theEmp.sectiondescription;
            theEmpModel.Greeting = theEmp.greetingen;

            return theEmpModel;
        }


        public static List<SelectListItem> getEmployeesListForDelegation(long employeeID)
        {
           

            employee[] employees = ECHO_Cache.AllEmployees;
            if (employees == null)
            {
                bool done = false;
                for (int i = 0; i < 3 && !done; i++)
                {
                    try
                    {
                        employees = ECHO_Cache.AllEmployees = empSvc.findAllAsync().GetAwaiter().GetResult().employee;
                        done = true;
                    }
                    catch (System.Exception e)
                    {
                        if (i == 2)
                            throw e;
                        Thread.Sleep(1500);
                    }
                }
            }

            List<SelectListItem> toBeReturned = new List<SelectListItem>();

            foreach (employee oneEmp in employees)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = oneEmp.id.ToString();
                if (EServicesWithAngular.DAL.Helper.Handler.HandleCultureName().Equals("ar"))
                    listItem.Text = oneEmp.name;
                else
                {
                    if (oneEmp.nameeng != null)
                        listItem.Text = oneEmp.nameeng.ToUpper();
                }
                toBeReturned.Add(listItem);
            }
            return toBeReturned.OrderBy(x => x.Text).ToList();
        }

        public static List<EmployeeModel> getAllEmployees()
        {
            List<EmployeeModel> toBeReturned = new List<EmployeeModel>();
           

            employee[] employees = ECHO_Cache.AllEmployees;
            if (employees == null)
            {
                bool done = false;
                for (int i = 0; i < 3 && !done; i++)
                {
                    try
                    {
                        employees = ECHO_Cache.AllEmployees = empSvc.findAllAsync().GetAwaiter().GetResult().employee;
                        done = true;
                    }
                    catch (System.Exception e)
                    {
                        if (i == 2)
                            throw e;
                        Thread.Sleep(1500);
                    }
                }
            }
            foreach (var emp in employees)
                toBeReturned.Add(getEmployeeModel(emp));
            return toBeReturned;
        }

        public static List<SelectListItem> getAllEmployeesList()
        {
           

            employee[] employees = ECHO_Cache.AllEmployees;
            if (employees == null)
            {
                bool done = false;
                for (int i = 0; i < 3 && !done; i++)
                {
                    try
                    {
                        employees = ECHO_Cache.AllEmployees = empSvc.findAllAsync().GetAwaiter().GetResult().employee;
                        done = true;
                    }
                    catch (System.Exception e)
                    {
                        if (i == 2)
                            throw e;
                        Thread.Sleep(1500);
                    }
                }
            }

            List<SelectListItem> toBeReturned = new List<SelectListItem>();

            foreach (employee oneEmp in employees)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = oneEmp.email.ToString();
                if (Handler.HandleCultureName().Equals("ar"))
                    listItem.Text = oneEmp.name;
                else
                {
                    if (oneEmp.nameeng != null)
                        listItem.Text = oneEmp.nameeng.ToUpper();
                }
                toBeReturned.Add(listItem);
            }
            return toBeReturned.OrderBy(x => x.Text).ToList();
        }

        internal static List<SelectListItem> getDepartmentEmployees(long departmentID)
        {
           

            listItem[] employees = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    employees = empSvc.findByDepartmentAsync(departmentID).GetAwaiter().GetResult().employee;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            List<SelectListItem> toBeReturned = new List<SelectListItem>();

            foreach (listItem oneEmp in employees)
            {
                SelectListItem listItem = new SelectListItem();
                listItem.Value = oneEmp.id.ToString();
                if (Handler.HandleCultureName().Equals("ar"))
                    listItem.Text = oneEmp.text;
                else
                    listItem.Text = oneEmp.text.ToUpper();

                toBeReturned.Add(listItem);
            }
            return toBeReturned.OrderBy(x => x.Text).ToList();
        }

        internal static List<EmployeeModel> getDirectSubordinates(string empEmail)
        {
           
            employee[] employees = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    employees = empSvc.findByDirecSubordinatesAsync(empEmail).GetAwaiter().GetResult().empdiectsubordinates;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }

            return getEmployeeModel(employees);
        }
        internal static List<EmployeeModel> getAllSubordinates(string empEmail)
        {
           

            employee[] employees = null;
            bool done = false;
            for (int i = 0; i < 3 && !done; i++)
            {
                try
                {
                    employees = empSvc.findByAllSubordinatesAsync(empEmail).GetAwaiter().GetResult().empdiectsubordinates;
                    done = true;
                }
                catch (System.Exception e)
                {
                    if (i == 2)
                        throw e;
                    Thread.Sleep(1500);
                }
            }
            return getEmployeeModel(employees);
        }

        private static List<EmployeeModel> getEmployeeModel(employee[] theEmps)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            if (theEmps != null)
                foreach (employee single in theEmps)
                    employees.Add(ECHO_Employee.getEmployeeModel(single));

            return employees;
        }

    }
}
