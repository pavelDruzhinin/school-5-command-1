<template>
  <v-container >
    <v-row no-gutters style="flex-wrap: nowrap;">
      
      <v-col
        cols="4"
        class="flex-grow-0 flex-shrink-0"
      >
        <v-card
          class="pa-2"
          outlined
          tile
        >
          <v-card
    :loading="loading"
    class="mx-auto my-12"
    max-width="374"
    v-for="(item,index) in items" :key="index">
    <div v-if="proId == item.userid">
    <v-img
      height="250"
      :src="item.image"
    ></v-img>
    

    <v-card-title>{{item.username}}</v-card-title>

    <v-card-text>
      <v-row
        align="center"
        class="mx-0"
      >
        <v-rating
          :value="4.5"
          color="amber"
          dense
          half-increments
          readonly
          size="14"
        ></v-rating>

        <div class="grey--text ml-4">4.5 (413)</div>
      </v-row>

      <div class="my-4 subtitle-1 black--text">
        Ваш возраст: {{item.ageuser}}
      </div>

      <div>Дата Регистрации : {{item.registdate}}</div>
    </v-card-text>

    <v-divider class="mx-4"></v-divider>

    <v-card-title>Архив созданных опросов <v-icon>mdi-forward</v-icon></v-card-title>

    <v-card-text>
      <v-chip-group
        v-model="selection"
        active-class="deep-purple accent-4 white--text"
        column
      >
        <v-chip>Изменить данные</v-chip>

        <v-chip>Удалить профиль</v-chip>
      </v-chip-group>
    </v-card-text>

    <v-card-actions>
    <!--  <v-btn
        color="deep-purple accent-4"
        text
        @click="reserve"
      > 
        Reserve
      </v-btn> -->
    </v-card-actions>
    </div>
  </v-card>
        </v-card>
      </v-col>
      <v-col
        cols="1"
        style="min-width: 100px; max-width: 100%;"
        class="flex-grow-1 "
      >
        <v-card
          class="pa-2"
          outlined
          tile
        >
        
          <section class="ma-5 mt-10" v-for="(post,index) in posts" :key="index" :class="`d-flex justify-center`" >
            <div v-if="proId == post.creator_id">
                <v-hover>
                        <template v-slot="{ hover }">
                        <v-card
                                class=" p-3"
                                max-width="400"
                                :elevation="hover ? 24 : 1" 
                                
                        >
                    <span v-bind:class="{'d-none': !post.canceled}">
                        <!--<v-icon  color="green"  class="pos"  medium large>
                            mdi-checkbox-marked
                            </v-icon>-->
                    </span>  
                            <v-img
                                    class="white--text align-end"
                                    
                                    height="200px"
                                    :src="post.image"
                            >
                            
                            <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                            </v-img>
                            

                            <v-card-subtitle class="pb-0">{{post.company}} </v-card-subtitle>

                            <v-card-text class=" pb-0">
                                <div ><h3 class="text--primary">{{post.title}}</h3></div>
                            
                                <!--<div v-for="post in posts" :key="post"><p>{{post.id}}</p></div>-->
                                <div >{{post.geo}} &#183; {{post.skills}}&#183; {{post.position}}</div>
                            </v-card-text>

                            <v-card-actions>
                                <v-btn
                                        color="cyan lighten-1"
                                        text
                                >
                                    begin
                                </v-btn>
                            </v-card-actions>
                            
                        </v-card>
                        </template>
                    </v-hover>
                    </div>
                </section> 
        

        </v-card>
      </v-col>
   
    </v-row>
  </v-container>
  
</template>
<script>
import axios from 'axios';
  export default {
    data() {
        return {
            proId:this.$route.params.Pid,
                items: [],
                posts: [],
        }
    },

created() {
      axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/user`)
      .then(response=> {
        this.items= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
      })
  axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/bots`)
      .then(response=> {
        this.posts= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
                })
        },
  }
  
</script>