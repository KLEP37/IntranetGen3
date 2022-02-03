﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensaGymnazium.IntranetGen3.Model.Security;

namespace MensaGymnazium.IntranetGen3.Model
{
	public class StudentSubjectRegistration
	{
		public int Id { get; set; }

		public Student Student { get; set; }
		public int StudentId { get; set; }

		public Subject Subject { get; set; }
		public int SubjectId { get; set; }

		public DateTime CreatedTime { get; set; }

		public StudentRegistrationType RegistrationType { get; set; }

		public SigningRule UsedSigningRule { get; set; }
		public int UsedSigningRuleId { get; set; }
	}
}