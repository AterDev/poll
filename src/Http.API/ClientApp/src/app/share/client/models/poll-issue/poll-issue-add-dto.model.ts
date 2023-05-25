import { PollType } from '../enum/poll-type.model';
/**
 * 议题投票实体类型
 */
export interface PollIssueAddDto {
  /**
   * 议题编号
   */
  issueNo: string;
  /**
   * 议题标题
   */
  title: string;
  /**
   * 议题描述
   */
  description: string;
  pollType?: PollType | null;
  /**
   * 有效开始时间
   */
  effectiveStartDate: Date;
  /**
   * 有效结束时间
   */
  effectiveEndDate: Date;
  pollOptionIds: string[];
  pollTagIds?: string[] | null;
  pollCategoryId?: string | null;

}
