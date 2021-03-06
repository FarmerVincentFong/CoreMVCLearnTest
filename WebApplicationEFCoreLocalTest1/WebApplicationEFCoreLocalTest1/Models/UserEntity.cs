﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationEFCoreLocalTest1.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    [Table("User")]
    [Serializable]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("age")]
        public short Age { get; set; }
        [Column("hobby")]
        public string Hobby { get; set; }
    }
}
