import { PollIssue } from '../poll-issue/poll-issue.model';
/**
 * 议题投票选项实体类型
 */
export interface PollOption {
  id: string;
  createdTime: Date;
  updatedTime: Date;
  /**
   * 软删除
   */
  isDeleted: boolean;
  /**
   * 选项描述
   */
  content: string;
  /**
   * 投票数
   */
  voteCount: number;
  /**
   * 议题投票实体类型
   */
  issue?: PollIssue | null;

}
