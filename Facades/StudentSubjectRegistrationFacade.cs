﻿using System.Security;
using MensaGymnazium.IntranetGen3.Contracts;
using MensaGymnazium.IntranetGen3.DataLayer.Queries;
using MensaGymnazium.IntranetGen3.DataLayer.Repositories;
using MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Authentication;
using MensaGymnazium.IntranetGen3.Model;
using MensaGymnazium.IntranetGen3.Primitives;

namespace MensaGymnazium.IntranetGen3.Facades;

[Service]
[Authorize]
public class StudentSubjectRegistrationFacade : IStudentSubjectRegistrationFacade
{
	private readonly IStudentSubjectRegistrationListQuery _studentSubjectRegistrationListQuery;
	private readonly IStudentSubjectRegistrationRepository _studentSubjectRegistrationRepository;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;

	public StudentSubjectRegistrationFacade(
		IStudentSubjectRegistrationListQuery studentSubjectRegistrationListQuery,
		IStudentSubjectRegistrationRepository studentSubjectRegistrationRepository,
		IUnitOfWork unitOfWork, IApplicationAuthenticationService applicationAuthenticationService)
	{
		_studentSubjectRegistrationListQuery = studentSubjectRegistrationListQuery;
		_studentSubjectRegistrationRepository = studentSubjectRegistrationRepository;
		_unitOfWork = unitOfWork;
		_applicationAuthenticationService = applicationAuthenticationService;
	}

	public async Task<DataFragmentResult<StudentSubjectRegistrationDto>> GetStudentSubjectRegistrationListAsync(DataFragmentRequest<StudentSubjectRegistrationListQueryFilter> studentSubjectRegistrationListRequest, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(studentSubjectRegistrationListRequest is not null);

		_studentSubjectRegistrationListQuery.Filter = studentSubjectRegistrationListRequest.Filter;
		_studentSubjectRegistrationListQuery.Sorting = studentSubjectRegistrationListRequest.Sorting;

		return await _studentSubjectRegistrationListQuery.GetDataFragmentAsync(studentSubjectRegistrationListRequest.StartIndex, studentSubjectRegistrationListRequest.Count, cancellationToken);
	}

	[Authorize(Roles = nameof(Role.Student))]
	public async Task<List<StudentSubjectRegistrationDto>> GetAllRegistrationsOfCurrentStudent()
	{
		var currentUser = _applicationAuthenticationService.GetCurrentUser();
		Contract.Requires<SecurityException>(currentUser.StudentId is not null);

		var registrations = await _studentSubjectRegistrationRepository.GetRegistrationsByStudent(currentUser.StudentId.Value);

		// Map
		var response = registrations.Select(r => new StudentSubjectRegistrationDto()
		{
			SubjectId = r.SubjectId,
			StudentId = r.StudentId,
			RegistrationType = r.RegistrationType,
			Id = r.Id
		}).ToList();

		return response;
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task<Dto<int>> CreateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(registrationDto != null);
		Contract.Requires<ArgumentException>(registrationDto.Id == default);

		var registration = new StudentSubjectRegistration();
		MapRegistrationFromDto(registrationDto, registration);

		_unitOfWork.AddForInsert(registration);
		await _unitOfWork.CommitAsync(cancellationToken);

		return Dto.FromValue(registration.Id);
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task UpdateRegistrationAsync(StudentSubjectRegistrationDto registrationDto, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentNullException>(registrationDto != null);
		Contract.Requires<ArgumentException>(registrationDto.Id != default);

		var registration = await _studentSubjectRegistrationRepository.GetObjectAsync(registrationDto.Id, cancellationToken);

		MapRegistrationFromDto(registrationDto, registration);

		_unitOfWork.AddForUpdate(registration);
		await _unitOfWork.CommitAsync(cancellationToken);
	}

	private void MapRegistrationFromDto(StudentSubjectRegistrationDto registrationDto, StudentSubjectRegistration registration)
	{
		registration.SubjectId = registrationDto.SubjectId.Value;
		registration.StudentId = registrationDto.StudentId.Value;
		registration.RegistrationType = registrationDto.RegistrationType.Value;
	}

	[Authorize(Roles = nameof(Role.Administrator))]
	public async Task DeleteRegistrationAsync(Dto<int> registrationIdDto, CancellationToken cancellationToken = default)
	{
		var registration = await _studentSubjectRegistrationRepository.GetObjectAsync(registrationIdDto.Value, cancellationToken);
		_unitOfWork.AddForDelete(registration);

		await _unitOfWork.CommitAsync(cancellationToken);
	}
}
