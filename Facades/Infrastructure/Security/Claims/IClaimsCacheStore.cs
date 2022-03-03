﻿using System.Security.Claims;

namespace MensaGymnazium.IntranetGen3.Facades.Infrastructure.Security.Claims;

public interface IClaimsCacheStore
{
	List<Claim> GetClaims(UserContextInfo userContextInfo);

	void StoreClaims(UserContextInfo userContextInfo, List<Claim> claims);
}
