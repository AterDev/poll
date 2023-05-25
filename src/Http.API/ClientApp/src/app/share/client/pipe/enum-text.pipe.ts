// 该文件自动生成，会被覆盖更新
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enumText'
})
export class EnumTextPipe implements PipeTransform {
  transform(value: unknown, type: string): unknown {
    let result = '';
    switch (type) {
      case 'PollType':
{
  switch (value)
  {
    case 0: result = '选举'; break;
    case 1: result = '议事'; break;
    default: '默认'; break;
  }
}
break;

      default:
        break;
    }
    return result;
  }
}