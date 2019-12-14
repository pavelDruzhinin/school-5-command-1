import { Column, Entity, OneToMany, PrimaryGeneratedColumn, ManyToOne, OneToOne } from 'typeorm';
import { User } from './user';
import { Question } from './question';

@Entity()
export class Bot {
  @PrimaryGeneratedColumn()
  id: number;

  @Column ({ unique: true })
  title: string;

  @Column ()
  description: string;

  @Column ()
  company: string;

  @Column ()
  answer: string;

    @Column()
    creatorId: number;

    @ManyToOne(() => User, user => user.bots)
    creator: Promise<User>;

}