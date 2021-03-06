﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Setme.Domain.Model
{
    /// <summary>
    /// 领域实体 实现类
    /// </summary>
    public class Entity : IEntity
    {
        public Entity()
        {
            id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public Guid id
        {
            get;
            private set;
        }

        [Timestamp]
        [Column(Order = 2)]
        public Byte[] TimeStamp { get; set; }


        /// <summary>
        /// 确定两个对象是否相等
        /// </summary>
        /// <param name="base1"></param>
        /// <param name="base2"></param>
        /// <returns></returns>
        public static bool operator ==(Entity base1, Entity base2)
        {
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }
            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }
            if (base1.id != base2.id)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 确定两个对象是否不相等
        /// </summary>
        /// <param name="base1"></param>
        /// <param name="base2"></param>
        /// <returns></returns>
        public static bool operator !=(Entity base1, Entity base2)
        {
            return !(base1 == base2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {
                return false;
            }
            return (this == (Entity)obj);
        }

        public override int GetHashCode()
        {
            if (this.id != null)
            {
                return this.id.GetHashCode();
            }
            return 0;
        }
    }
}
