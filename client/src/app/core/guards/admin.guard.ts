import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';
import { SnakbarService } from '../services/snakbar.service';


export const adminGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);
  const snack = inject(SnakbarService);

  if (accountService.isAdmin()) {
    return true;
  } else {
    snack.error('Nope');
    router.navigateByUrl('/shop');
    return false;
  }
};