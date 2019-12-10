<template>
    <div>
        <v-card >
            <v-card-title>
                Registered user
                <v-spacer></v-spacer>
                <v-text-field
                        append-icon="mdi-search-web"
                        label="Search"
                        single-line
                        hide-details
                        v-model="search"
                ></v-text-field>
            </v-card-title>
            <v-data-table
                    v-model="selected"
                    :headers="headers"
                    :items="items"
                    :search="search"
                    @onRowClick="openDetail"
                    

            >
                <template v-slot:item="props" 
                 >
                    <tr>
                        <td v-for="id in id"
        :key="id">{{ props.item.userid }}</td>
                        <td @click="goTodetail(props.item.userid)" class="text-xs-right" >{{ props.item.username }}</td>
                        <td class="text-xs-right">{{ props.item.ageuser }}</td>
                        <td class="text-xs-right">{{ props.item.registdate }}</td>
                    </tr>
                </template>
                <v-alert slot="no-results" :value="true" color="error" icon="warning">
                    Your search for "{{ search }}" found no results.
                </v-alert>
            </v-data-table>
        </v-card>
    </div>
</template>
<script>
        import axios from 'axios';
    export default {

        data() {
            return {
                selected: [],
                search: '',
                items: [],
                headers: [
                    {
                        text: 'User name',
                        align: 'left',
                        sortable: false,
                        value: 'name'
                    },
                    {text: 'Age user', value: 'ageuser'},
                    {text: 'Registration date', value: 'registdate'},
                ],
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

    },
    methods: {
         openDetail(a) {
                if (event.target.classList.contains('btn__content')) return;
                alert('Polls title: \n' + a.userid);
            },
    goTodetail (prodId) {
      let proId=prodId
      this.$router.push({name: 'user', params: {Pid: proId}})
    }
  }
    }
</script>