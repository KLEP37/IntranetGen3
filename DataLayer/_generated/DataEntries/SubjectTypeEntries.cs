﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MensaGymnazium.IntranetGen3.DataLayer.DataEntries;

[System.CodeDom.Compiler.GeneratedCode("Havit.Data.EntityFrameworkCore.CodeGenerator", "1.0")]
public class SubjectTypeEntries : Havit.Data.Patterns.DataEntries.DataEntries<MensaGymnazium.IntranetGen3.Model.SubjectType>, ISubjectTypeEntries 
{
	private MensaGymnazium.IntranetGen3.Model.SubjectType artCulture;
	private MensaGymnazium.IntranetGen3.Model.SubjectType humanHealth;
	private MensaGymnazium.IntranetGen3.Model.SubjectType humanNature;
	private MensaGymnazium.IntranetGen3.Model.SubjectType humanSociety;
	private MensaGymnazium.IntranetGen3.Model.SubjectType humanWork;
	private MensaGymnazium.IntranetGen3.Model.SubjectType informatics;
	private MensaGymnazium.IntranetGen3.Model.SubjectType languageCommunication;
	private MensaGymnazium.IntranetGen3.Model.SubjectType mathApplication;

	public MensaGymnazium.IntranetGen3.Model.SubjectType ArtCulture => artCulture ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.ArtCulture);
	public MensaGymnazium.IntranetGen3.Model.SubjectType HumanHealth => humanHealth ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.HumanHealth);
	public MensaGymnazium.IntranetGen3.Model.SubjectType HumanNature => humanNature ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.HumanNature);
	public MensaGymnazium.IntranetGen3.Model.SubjectType HumanSociety => humanSociety ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.HumanSociety);
	public MensaGymnazium.IntranetGen3.Model.SubjectType HumanWork => humanWork ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.HumanWork);
	public MensaGymnazium.IntranetGen3.Model.SubjectType Informatics => informatics ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.Informatics);
	public MensaGymnazium.IntranetGen3.Model.SubjectType LanguageCommunication => languageCommunication ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.LanguageCommunication);
	public MensaGymnazium.IntranetGen3.Model.SubjectType MathApplication => mathApplication ??= GetEntry(MensaGymnazium.IntranetGen3.Model.SubjectType.Entry.MathApplication);

	public SubjectTypeEntries(MensaGymnazium.IntranetGen3.DataLayer.Repositories.ISubjectTypeRepository repository)
		: base(repository)
	{
	}
}
