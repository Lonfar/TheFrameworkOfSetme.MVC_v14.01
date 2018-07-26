
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Setme.Domain.Model
{
    public class Employee : AggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
#pragma warning disable RECS0021 // 就构造函数中发生的对虚拟成员函数的调用发出警告
            this.Role = new HashSet<Role>();
#pragma warning restore RECS0021 // 就构造函数中发生的对虚拟成员函数的调用发出警告
        }

        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [MinLength(6, ErrorMessage = "{0}必须大于{1}."), MaxLength(18, ErrorMessage = "{0}必须小于{1}.")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [MinLength(6, ErrorMessage = "{0}必须大于{1}."), MaxLength(18, ErrorMessage = "{0}必须小于{1}.")]
        public string PassWord { get; set; }

        [Display(Name = "真实姓名")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [MinLength(2, ErrorMessage = "{0}必须大于{1}."), MaxLength(6, ErrorMessage = "{0}必须小于{1}.")]
        public string RealName { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "{0}不能为空.")]
        public EnumStatus.SexStatus Sex { get; set; }

        [Display(Name = "手机号码")]
        [Phone(ErrorMessage = "{0}格式不正确.")]
        public string Phone { get; set; }

        [Display(Name = "座机")]
        public string Tel { get; set; }

        [Display(Name = "电子邮箱")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [EmailAddress(ErrorMessage = "{0}格式不正确.")]
        public string Email { get; set; }

        [Display(Name = "是否启动")]
        [Required(ErrorMessage = "{0}不能为空.")]
        public EnumStatus.OpenStatus Open { get; set; }

        public virtual ICollection<Role> Role { get; set; }

        /// <summary>
        /// 创建Employee实体
        /// </summary>
        /// <param name="_UserName">用户名</param>
        /// <param name="_PassWord">密码</param>
        /// <param name="_RealName">真实姓名</param>
        /// <param name="_Sex">性别</param>
        /// <param name="_Phone">手机号</param>
        /// <param name="_Tel">电话号</param>
        /// <param name="_Email">邮箱</param>
        /// <param name="_Open">是否开启</param>
        /// <returns>实体类型</returns>
        public static Employee CreateEmployee(string _UserName, string _PassWord, string _RealName,
                                               EnumStatus.SexStatus _Sex, string _Phone, string _Tel,
                                               string _Email, EnumStatus.OpenStatus _Open)
        {
            Employee employee = new Employee();
            employee.UserName = _UserName;
            employee.PassWord = _PassWord;
            employee.RealName = _RealName;
            employee.Sex = _Sex;
            employee.Phone = _Phone;
            employee.Tel = _Tel;
            employee.Email = _Email;
            employee.Open = _Open;
            return employee;
        }

        /// <summary>
        /// 状态切换off or on
        /// </summary>
        public void ReSwitch()
        {
            if (this.Open == EnumStatus.OpenStatus.On)
                this.Open = EnumStatus.OpenStatus.Off;
            else
                this.Open = EnumStatus.OpenStatus.On;
        }

        /// <summary>
        /// 设定初始密码
        /// </summary>
        public void RePassword()
        {
            this.PassWord = "000000";
        }
    }
}
