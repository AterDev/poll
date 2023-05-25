import { PollIssue } from '../poll-issue/poll-issue.model';
/**
 * 议题分类
 */
export interface PollTag {
  id: string;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 软删除
   */
  isDeleted: boolean;
  name: string;
  /**
   * 议题投票实体类型
   */
  pollIssue?: PollIssue | null;

}
