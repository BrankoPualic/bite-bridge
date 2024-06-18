﻿using BiteBridge.Common.Enums;
using BiteBridge.Common.Extensions;
using BiteBridge.Common.Interfaces;
using BiteBridge.Web.Api.Extensions;

namespace BiteBridge.Web.Api.Objects;

public class IdentityUser : IIdentityUser
{
	private readonly IHttpContextAccessor _httpContextAccessor;
	private bool _isParsed;
	private Guid _id;
	private string _username;
	private string _email;
	private List<eSystemRole> _roles;
	private bool _isAuthenticated;

	public IdentityUser(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
		_isParsed = false;
	}

	public Guid Id
	{
		get
		{
			ParseIdentity();
			return _id;
		}
	}

	public string Email
	{
		get
		{
			ParseIdentity();
			return _email;
		}
	}

	public string Username
	{
		get
		{
			ParseIdentity();
			return _username;
		}
	}

	public List<eSystemRole> Roles
	{
		get
		{
			ParseIdentity();
			return _roles;
		}
	}

	public bool IsAuthenticated
	{
		get
		{
			ParseIdentity();
			return _isAuthenticated;
		}
	}

	public bool HasRole(List<eSystemRole> roles)
	{
		return roles.Any(Roles.Contains);
	}

	private void ParseIdentity()
	{
		if (!_isParsed)
		{
			var user = _httpContextAccessor?.HttpContext?.User;

			if (user is null)
			{
				return;
			}

			_isAuthenticated = user.Identity!.IsAuthenticated;

			if (_isAuthenticated)
			{
				_id = user.Claims.GetId();
				_email = user.Claims.GetEmail();
				_username = user.Claims.GetUsername();
				_roles = user.Claims.GetRoles().GetEnumList<eSystemRole>();
			}
		}

		_isParsed = true;
	}
}