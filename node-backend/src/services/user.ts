import { getManager } from 'typeorm';
import { User } from '../models/user';

export async function assertUser(oktaUserId: string) {
  const manager = getManager();
  const existingUser = await manager.findOne(User, { where: { oktaUserId } });
  if (existingUser) {
    return existingUser;
  }

  const user = new User();
  user.oktaUserId = oktaUserId;
  return await manager.save(user);
}