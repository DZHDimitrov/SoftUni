import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllTeams() {
    const teams = await api.get('http://localhost:3030/data/teams');
    const members = await getMembers(teams.map(x=> x._id));
    teams.forEach(x=> x.memberCount = members.filter(m => m.teamId == x._id).length);
    return teams;
}

export async function makeNewTeam(data) {
    const result = await api.post('http://localhost:3030/data/teams',data);
    const request = await requestToJoin(result._id);
    await approveMembership(request);
    return result;
}

export async function getTeamById(id) {
    return await api.get('http://localhost:3030/data/teams/'+ id);
}

export async function editTeamById(id,data){
    return await api.put('http://localhost:3030/data/teams/' + id,data);
}

export async function getMembers(teamIds) {
    const query = encodeURIComponent(`teamId IN ("${teamIds.join('", "')}") AND status="member"`);
    return await api.get(`http://localhost:3030/data/members?where=${query}`)
}

export async function requestToJoin(teamId){
    const body = {teamId};
    return await api.post('http://localhost:3030/data/members',body);
}

export async function getRequestsByTeamId(teamId) {
    return await api.get(`http://localhost:3030/data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`);
}

export async function cancelMembership(requestId) {
    return await api.del('http://localhost:3030/data/members/'+ requestId);
}

export async function approveMembership(request){
    const body = {
        teamId: request.teamId,
        status: 'member',
    }

    return await api.put('http://localhost:3030/data/members/'+request._id,body);
}

export async function getMyTeams(){
    const userId = sessionStorage.getItem('userId');
    const [teamsCreated,teamMember] = await Promise.all([
        api.get('http://localhost:3030/data/members?where=_ownerId%3D%22${userId}%22'),
        api.get(`http://localhost:3030/data/members?where=_ownerId%3D%22${userId}%22%20AND%20status%3D%22member%22&load=team%3DteamId%3Ateams`),
    ]);
    const teams = teamsCreated.concat(teamMember.map(r => r.team));
    const members = await getMembers(teams.map(x=> x._id));
    teams.forEach(x=> x.memberCount = members.filter(m => m.teamId == x._id).length);
    return teams;
}
