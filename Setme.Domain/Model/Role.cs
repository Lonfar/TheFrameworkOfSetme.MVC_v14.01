using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Setme.Domain.Model
{
    public class Role : AggregateRoot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
#pragma warning disable RECS0021 // 就构造函数中发生的对虚拟成员函数的调用发出警告
            this.Employee = new HashSet<Employee>();
#pragma warning restore RECS0021 // 就构造函数中发生的对虚拟成员函数的调用发出警告
            Order = 0;
            Open = EnumStatus.OpenStatus.Off;
        }

        [Display(Name = "角色名")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [MinLength(2, ErrorMessage = "{0}必须大于{1}."), MaxLength(20, ErrorMessage = "{0}必须小于{1}.")]
        public string RoleName { get; set; }

        [Display(Name = "角色说明")]
        [Required(ErrorMessage = "{0}不能为空.")]
        [MinLength(2, ErrorMessage = "{0}必须大于{1}."), MaxLength(200, ErrorMessage = "{0}必须小于{1}.")]
        public string RoleDescription { get; set; }

        [Display(Name = "排序")]
        public int Order { get; set; }

        [Display(Name = "是否启动")]
        [Required(ErrorMessage = "{0}不能为空.")]
        public EnumStatus.OpenStatus Open { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }

        /// <summary>
        /// 创建Role实体
        /// </summary>
        /// <param name="_RoleName"></param>
        /// <param name="_RoleDescription"></param>
        /// <returns></returns>
        public  Role CreateRole(string _RoleName, string _RoleDescription)
        {
            Role role = new Role();
            role.RoleName = _RoleName;
            role.RoleDescription = _RoleDescription;
            return role;
        }

        /// <summary>
        /// 切换状态 off or on
        /// </summary>
        public void ReSwitch()
        {
            if (this.Open == EnumStatus.OpenStatus.On)
                this.Open = EnumStatus.OpenStatus.Off;
            else
                this.Open = EnumStatus.OpenStatus.On;
        }

    }
}
