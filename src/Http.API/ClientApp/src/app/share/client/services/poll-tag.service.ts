import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { PollTagFilterDto } from '../models/poll-tag/poll-tag-filter-dto.model';
import { PollTagAddDto } from '../models/poll-tag/poll-tag-add-dto.model';
import { PollTagUpdateDto } from '../models/poll-tag/poll-tag-update-dto.model';
import { PollTagItemDtoPageList } from '../models/poll-tag/poll-tag-item-dto-page-list.model';
import { PollTag } from '../models/poll-tag/poll-tag.model';

/**
 * 议题分类
 */
@Injectable({ providedIn: 'root' })
export class PollTagService extends BaseService {
  /**
   * 筛选
   * @param data PollTagFilterDto
   */
  filter(data: PollTagFilterDto): Observable<PollTagItemDtoPageList> {
    const url = `/api/PollTag/filter`;
    return this.request<PollTagItemDtoPageList>('post', url, data);
  }

  /**
   * 新增
   * @param data PollTagAddDto
   */
  add(data: PollTagAddDto): Observable<PollTag> {
    const url = `/api/PollTag`;
    return this.request<PollTag>('post', url, data);
  }

  /**
   * 更新
   * @param id 
   * @param data PollTagUpdateDto
   */
  update(id: string, data: PollTagUpdateDto): Observable<PollTag> {
    const url = `/api/PollTag/${id}`;
    return this.request<PollTag>('put', url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<PollTag> {
    const url = `/api/PollTag/${id}`;
    return this.request<PollTag>('get', url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<PollTag> {
    const url = `/api/PollTag/${id}`;
    return this.request<PollTag>('delete', url);
  }

}
