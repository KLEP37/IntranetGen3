﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Havit.Data.EntityFrameworkCore.Patterns.DataSources.Fakes;
using Havit.Data.EntityFrameworkCore.Patterns.SoftDeletes;
using Havit.Data.Patterns.Attributes;

namespace MensaGymnazium.IntranetGen3.DataLayer.DataSources.Fakes;

[Fake]
[System.CodeDom.Compiler.GeneratedCode("Havit.Data.EntityFrameworkCore.CodeGenerator", "1.0")]
public class FakeSubjectCategoryDataSource : FakeDataSource<MensaGymnazium.IntranetGen3.Model.SubjectCategory>, MensaGymnazium.IntranetGen3.DataLayer.DataSources.ISubjectCategoryDataSource
{
	public FakeSubjectCategoryDataSource(params MensaGymnazium.IntranetGen3.Model.SubjectCategory[] data)
		: this((IEnumerable<MensaGymnazium.IntranetGen3.Model.SubjectCategory>)data)
	{			
	}

	public FakeSubjectCategoryDataSource(IEnumerable<MensaGymnazium.IntranetGen3.Model.SubjectCategory> data, ISoftDeleteManager softDeleteManager = null)
		: base(data, softDeleteManager)
	{
	}
}
