import { PollType } from '../enum/poll-type.model';
/**
 * 议题投票实体类型
 */
export interface PollIssueFilterDto {
  pageIndex: number;
  /**
   * 默认最大1000
   */
  pageSize: number;
  /**
   * 排序
   */
  orderBy?: any | null;
  /**
   * 议题编号
   */
  issueNo?: string | null;
  /**
   * 议题标题
   */
  title?: string | null;
  pollType?: PollType | null;
  /**
   * 有效开始时间
   */
  effectiveStartDate?: Date | null;
  /**
   * 有效结束时间
   */
  effectiveEndDate?: Date | null;
  categoryId?: string | null;

}
