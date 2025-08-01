﻿using SIMSWeb.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMSWeb.Business.IService
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachers();
        Task AddTeacher(Teacher teacher);
        Task UpdateTeacher(Teacher teacher);
        Task DeleteTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(int id);
    }
}
