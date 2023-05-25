import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { PollCategoryFilterDto } from '../models/poll-category/poll-category-filter-dto.model';
import { PollCategoryAddDto } from '../models/poll-category/poll-category-add-dto.model';
import { PollCategoryUpdateDto } from '../models/poll-category/poll-category-update-dto.model';
import { PollCategoryItemDtoPageList } from '../models/poll-category/poll-category-item-dto-page-list.model';
import { PollCategory } from '../models/poll-category/poll-category.model';

/**
 * PollCategory
 */
@Injectable({ providedIn: 'root' })
export class PollCategoryService extends BaseService {
  /**
   * 筛选
   * @param data PollCategoryFilterDto
   */
  filter(data: PollCategoryFilterDto): Observable<PollCategoryItemDtoPageList> {
    const url = `/api/PollCategory/filter`;
    return this.request<PollCategoryItemDtoPageList>('post', url, data);
  }

  /**
   * 新增
   * @param data PollCategoryAddDto
   */
  add(data: PollCategoryAddDto): Observable<PollCategory> {
    const url = `/api/PollCategory`;
    return this.request<PollCategory>('post', url, data);
  }

  /**
   * 更新
   * @param id 
   * @param data PollCategoryUpdateDto
   */
  update(id: string, data: PollCategoryUpdateDto): Observable<PollCategory> {
    const url = `/api/PollCategory/${id}`;
    return this.request<PollCategory>('put', url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<PollCategory> {
    const url = `/api/PollCategory/${id}`;
    return this.request<PollCategory>('get', url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<PollCategory> {
    const url = `/api/PollCategory/${id}`;
    return this.request<PollCategory>('delete', url);
  }

}
