/**
 * 议题投票选项实体类型查询筛选
 */
export interface PollOptionFilterDto {
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
   * 选项描述
   */
  content?: string | null;
  /**
   * 投票数
   */
  voteCount?: number | null;
  issueId?: string | null;

}
