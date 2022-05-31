﻿using Microsoft.AspNetCore.Identity;

namespace JackStore.ViewModel
{
    public static class RegistroMapper
    {
        public static IdentityUser<int> ToDmain(this RegistroViewModel from)
        {
            // TODO: incluir no BD o campo NOME dos usuários ao registrá-lo
            var to = new IdentityUser<int> { UserName = from.Email, Email = from.Email };
            return to;
        }
    }
}