import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { BalanceService } from '../../services/balance.service';
import { CurrencyService } from '../../services/currency.service';
import { Balance } from '../../models/Balance';
import { Currency } from '../../models/Currency';
import { User } from '../../models/User';

@Component({
  selector: 'app-user-balance',
  templateUrl: './user-balance.component.html',
  styleUrls: ['./user-balance.component.css']
})
export class UserBalanceComponent implements OnChanges {

  @Input() selectedUser: User | undefined;

  currencies$: Observable<Currency[]> | undefined;
  balance$: Observable<Balance> | undefined;

  withdrawAmount: FormControl = new FormControl('', Validators.required);
  depositAmount: FormGroup;

  constructor(
    private balanceService: BalanceService, 
    private currencyService: CurrencyService,
    private fb: FormBuilder) {
      this.currencies$ = currencyService.getCurrencies();
      this.depositAmount = fb.group({
        amount: '',
        currencyCode: 'EUR'
      })
   }

  ngOnChanges(changes: SimpleChanges): void {
    if(this.selectedUser){
      this.balance$ = this.balanceService.GetBalance(this.selectedUser.userId);
    }
  }

  withdraw(){
    if (!this.withdrawAmount.valid) {
      return;
    }

    // this.balanceService.withdraw(this.withdrawAmount.value)
    // .pipe(

    // )
  }

}
