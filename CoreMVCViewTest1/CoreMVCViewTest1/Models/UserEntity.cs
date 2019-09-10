using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMVCViewTest1.Models
{
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
        public int Age { get; set; }
        [Column("hobby")]
        public string Hobby { get; set; }

        //设置属性值，除了主键不修改
        public void SetValNoPk(UserEntity newUser)
        {
            if (newUser != null)
            {
                this.Name = newUser.Name;
                this.Age = newUser.Age;
                this.Hobby = newUser.Hobby;
            }
        }
    }
}
