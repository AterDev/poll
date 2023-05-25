import { PollIssueItemDto } from '../poll-issue/poll-issue-item-dto.model';
export interface PollIssueItemDtoPageList {
  count: number;
  data?: PollIssueItemDto[];
  pageIndex: number;

}
