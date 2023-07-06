import { Pipe, PipeTransform } from '@angular/core';
import { CurrencyPipe } from '@angular/common';

@Pipe({
  name: 'brlCurrency'
})
export class BrlCurrencyPipe implements PipeTransform {
  transform(value: number | string, symbol: string = 'R$', digitsInfo: string = '1.2-2'): string {
    const currencyPipe = new CurrencyPipe('pt-BR');
    return currencyPipe.transform(value, symbol, 'symbol', digitsInfo);
  }
}
