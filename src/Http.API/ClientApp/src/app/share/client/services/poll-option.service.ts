import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { PollOptionFilterDto } from '../models/poll-option/poll-option-filter-dto.model';
import { PollOptionAddDto } from '../models/poll-option/poll-option-add-dto.model';
import { PollOptionUpdateDto } from '../models/poll-option/poll-option-update-dto.model';
import { PollOptionItemDtoPageList } from '../models/poll-option/poll-option-item-dto-page-list.model';
import { PollOption } from '../models/poll-option/poll-option.model';

/**
 * 议题投票选项实体类型
 */
@Injectable({ providedIn: 'root' })
export class PollOptionService extends BaseService {
  /**
   * 筛选
   * @param data PollOptionFilterDto
   */
  filter(data: PollOptionFilterDto): Observable<PollOptionItemDtoPageList> {
    const url = `/api/PollOption/filter`;
    return this.request<PollOptionItemDtoPageList>('post', url, data);
  }

  /**
   * 新增
   * @param data PollOptionAddDto
   */
  add(data: PollOptionAddDto): Observable<PollOption> {
    const url = `/api/PollOption`;
    return this.request<PollOption>('post', url, data);
  }

  /**
   * 更新
   * @param id 
   * @param data PollOptionUpdateDto
   */
  update(id: string, data: PollOptionUpdateDto): Observable<PollOption> {
    const url = `/api/PollOption/${id}`;
    return this.request<PollOption>('put', url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<PollOption> {
    const url = `/api/PollOption/${id}`;
    return this.request<PollOption>('get', url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<PollOption> {
    const url = `/api/PollOption/${id}`;
    return this.request<PollOption>('delete', url);
  }

}
