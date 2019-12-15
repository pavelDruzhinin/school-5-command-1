<template>
    
      <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="600"
                            
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="250px"
                            :src="posts.image"
                    >
                    </v-img>

                    <v-card-subtitle class="pb-0">{{posts.company}}</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h2 class="text--primary my-1">{{posts.title}}</h2></div>
                        <div class="pb-0">{{posts.skills}}</div>
                        <h3 class="text--primary my-3" >About our company</h3>
                            <p class="text--primary">
                                {{posts.description}}
                            </p>
                            <h3 class="text--primary">Мы предлагаем дорогому соискателю, пройти небольшой опрос,
                               на основании которого мы будем рассматривать вашу Кандидатуру
                            </h3>
                    </v-card-text>

                    <v-card>
                      
          <v-list-item v-for="question in posts.questions" :key="question.questions_id">
            <v-list-item-content>
              <v-list-item-title>
                <p>{{question.title}}</p>
              </v-list-item-title>
             <v-text-field clear-icon="mdi-close-circle" clearable :rules="formIsValid" v-model="question1"
                  label="Answer:" type="text" @click:clear="clearMessage"></v-text-field>
            </v-list-item-content>
          </v-list-item>
          
           
                        
                    </v-card>
                    <v-btn class="ma-3" 
                                color="cyan lighten-1"
                                text
                        @click="goTodetail(props.item.id)">
                            send
                        </v-btn>
                </v-card>
                </template>
            </v-hover>
        </section>  
</template>

<script>
    import axios from 'axios';
    export default {
        data() {
            return {
                proId:this.$route.params.Pid,
                direction: 'bottom',
                fab: false,
                globalid: null,
                dialog: false,
                redactPost: false,
                message: null,
                question1:null,
                show: true,
                n: 0,
                items: [],
                posts: [],
                errors: [],
                redlabel: "",
                formIsValid: [
                    (v) => !!v || 'Field is required'
                ]
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
        this.posts= response.data[this.proId];
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
                })
        },

        methods: {
      clearMessage() {
        this.message = ''
      },
      
        
            }
    }
        
    
</script>


 