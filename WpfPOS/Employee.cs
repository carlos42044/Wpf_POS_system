using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPOS
{
    class Employee
    {
        private String firstName;
        private String lastName;
        private int employeeId;
        private static int id = 1000;

        public Employee()
        {
            this.employeeId = id;
            this.lastName = "User #" + id;
            id++;
        }

        public Employee(String firstName, String lastName)
        {
            this.employeeId = id;
            this.firstName = firstName;
            this.lastName = lastName;
            id++;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public int getEmployeeId()
        {
            return employeeId;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public String ToString()
        {
            return "Employee ID: " + employeeId + " Name: " + firstName + " " + lastName;
        }
    }
}
