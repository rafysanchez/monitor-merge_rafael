import { FilterRule } from './filter.rule';
export class SearchRequest {
    public Filter: FilterRule;
    public OrderBy: string;
    public PageNumber: number;
    public RecordsPerPage: number;
    public SortDirection: string;
}
