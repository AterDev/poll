/**
 * 议题投票选项实体类型更新时请求结构
 */
export interface PollOptionUpdateDto {
  /**
   * 选项描述
   */
  content: string;
  /**
   * 投票数
   */
  voteCount?: number | null;
  pollIssueId: string;

}
