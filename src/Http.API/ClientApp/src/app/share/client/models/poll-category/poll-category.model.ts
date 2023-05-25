import { PollIssue } from '../poll-issue/poll-issue.model';
export interface PollCategory {
  id: string;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 软删除
   */
  isDeleted: boolean;
  name: string;
  issues?: PollIssue[] | null;

}
