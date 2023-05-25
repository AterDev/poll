/**
 * 议题分类查询筛选
 */
export interface PollTagFilterDto {
  pageIndex: number;
  /**
   * 默认最大1000
   */
  pageSize: number;
  /**
   * 排序
   */
  orderBy?: any | null;
  name?: string | null;
  pollIssueId?: string | null;

}
