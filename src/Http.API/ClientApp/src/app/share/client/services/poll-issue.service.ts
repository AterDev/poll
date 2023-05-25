import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';
import { PollIssueFilterDto } from '../models/poll-issue/poll-issue-filter-dto.model';
import { PollIssueAddDto } from '../models/poll-issue/poll-issue-add-dto.model';
import { PollIssueUpdateDto } from '../models/poll-issue/poll-issue-update-dto.model';
import { PollIssueItemDtoPageList } from '../models/poll-issue/poll-issue-item-dto-page-list.model';
import { PollIssue } from '../models/poll-issue/poll-issue.model';

/**
 * 议题投票实体类型
 */
@Injectable({ providedIn: 'root' })
export class PollIssueService extends BaseService {
  /**
   * 筛选
   * @param data PollIssueFilterDto
   */
  filter(data: PollIssueFilterDto): Observable<PollIssueItemDtoPageList> {
    const url = `/api/PollIssue/filter`;
    return this.request<PollIssueItemDtoPageList>('post', url, data);
  }

  /**
   * 新增
   * @param data PollIssueAddDto
   */
  add(data: PollIssueAddDto): Observable<PollIssue> {
    const url = `/api/PollIssue`;
    return this.request<PollIssue>('post', url, data);
  }

  /**
   * 更新
   * @param id 
   * @param data PollIssueUpdateDto
   */
  update(id: string, data: PollIssueUpdateDto): Observable<PollIssue> {
    const url = `/api/PollIssue/${id}`;
    return this.request<PollIssue>('put', url, data);
  }

  /**
   * 详情
   * @param id 
   */
  getDetail(id: string): Observable<PollIssue> {
    const url = `/api/PollIssue/${id}`;
    return this.request<PollIssue>('get', url);
  }

  /**
   * ⚠删除
   * @param id 
   */
  delete(id: string): Observable<PollIssue> {
    const url = `/api/PollIssue/${id}`;
    return this.request<PollIssue>('delete', url);
  }

}
